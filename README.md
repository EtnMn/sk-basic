# SK.Basic Solution Overview

## Init solution
```sh
dotnet new sln
dotnet sln migrate 
dotnet new globaljson --sdk-version 10.0.100-rc.1.25451.107 --roll-forward latestFeature
dotnet new console --output sk.basic.front --framework net10.0
dotnet sln add sk.basic.front
dotnet add package Microsoft.Extensions.Hosting --project sk.basic.front
dotnet add package Microsoft.SemanticKernel --project sk.basic.front
dotnet add package Microsoft.Extensions.Options.DataAnnotations --project sk.basic.front
```

## Init secrets
dotnet user-secrets init
dotnet user-secrets set "SemanticKernel:ApiKey" "your-api-key-here" 

## Getting Started
1. Restore and build:
	 ```sh
	 dotnet restore
	 dotnet build
	 ```
2. Run the application:
	 ```sh
	 dotnet run --project src/Front/Front.csproj
	 ```
3. Configure secrets:
	 ```sh
	 dotnet user-secrets init --project src/Front/Front.csproj
	 dotnet user-secrets set "SemanticKernel:ApiKey" "your-api-key-here" --project src/Front/Front.csproj
	 ```

## Configuration
- Update `appsettings.json` with your Semantic Kernel settings:
	```json
	{
		"SemanticKernel": {
			"ApiKey": "your-api-key-here",
			"Endpoint": "https://your-endpoint",
			"DeploymentName": "your-deployment-name"
		}
	}
	```