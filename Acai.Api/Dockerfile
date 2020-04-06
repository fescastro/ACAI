FROM microsoft/dotnet:2.2-sdk as build

ARG BUILDCONFIG-RELEASE
ARG VERSION-1.0.0

COPY Acai.Api.csproj /build/

RUN dotnet restore ./build/Acai.Api.csproj

COPY . ./build/
WORKDIR /build/
RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app

COPY --from=build /build/out .

ENTRYPOINT [ "dotnet","Acai.Api.dll" ]