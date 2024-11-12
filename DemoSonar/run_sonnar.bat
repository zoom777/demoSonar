dotnet sonarscanner begin   /o:"contosodemo"   /k:"zoom777_demoSonar"   /d:sonar.host.url="https://sonarcloud.io"   /d:sonar.token="d5e72feb1b1ee4fdc2e84590cb0dfd604508d7ca"
dotnet build
dotnet sonarscanner end /d:sonar.token="d5e72feb1b1ee4fdc2e84590cb0dfd604508d7ca"