FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS test
COPY . /src
WORKDIR /src
RUN dotnet test

FROM test as build
RUN dotnet publish katsuben/katsuben.csproj -c Release -r linux-x64 --self-contained=true -p:PublishSingleFile=true

FROM mcr.microsoft.com/dotnet/runtime-deps:5.0-buster-slim
# Enable detection of running in a container
ENV DOTNET_RUNNING_IN_CONTAINER=true
WORKDIR /app
RUN apt-get update \
    && apt-get install -y --no-install-recommends \
        ca-certificates \
        \
        # .NET Core dependencies
        libc6 \
        libgcc1 \
        libgssapi-krb5-2 \
        libicu63 \
        libssl1.1 \
        libstdc++6 \
        zlib1g \
    && rm -rf /var/lib/apt/lists/*

COPY --from=build /src/katsuben/bin/Release/net5.0/linux-x64/publish/ /app
CMD ["./katsuben"]
