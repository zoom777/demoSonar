dotnet sonarscanner begin /o:"usuariotmp001" /k:"usuariotmp001_demoSonar" /d:sonar.host.url="https://sonarcloud.io" /d:sonar.token="ca62dcb0d053760142e0b51651313e66729f8716"
dotnet build
dotnet sonarscanner end /d:sonar.token="ca62dcb0d053760142e0b51651313e66729f8716"