FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build
COPY . /src
WORKDIR /src
RUN dotnet publish -c Release -r linux-x64 --self-contained=true -p:PublishSingleFile=true

FROM debian:buster-slim AS final
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
WORKDIR /app
COPY --from=build /src/katsuben/bin/Release/net5.0/linux-x64/publish/ /app
CMD ["./katsuben"]
