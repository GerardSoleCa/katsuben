FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env

ENV SUBTITLE_EDIT_VERSION=3.5.15

WORKDIR /subtitle_edit
RUN curl -L >subtitle_edit.tar.gz https://github.com/SubtitleEdit/subtitleedit/archive/${SUBTITLE_EDIT_VERSION}.tar.gz \
 && tar -xzvf subtitle_edit.tar.gz 

WORKDIR /subtitle_edit/subtitleedit-${SUBTITLE_EDIT_VERSION}/

RUN sed -i '/build_helpers.bat/d' libse/LibSE.csproj 
RUN dotnet build libse/LibSE.csproj /p:Configuration=Release /p:TargetFramework=netstandard2.1
