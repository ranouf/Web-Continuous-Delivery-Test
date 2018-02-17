# How to use Azure Continuous delivery for WebJob with Asp.Net Core?
You have probably noticed that it's not possible anymore to deploy a WebJob from Visual Studio with Asp.net Core. You currently need to publish the WebJob in a folder, zip the folder and add it from the Azure Portal, which is really not efficient.

# Steps:
## 1/ Configure Azure
On <a href="https://portal.azure.com">Azure Portal</a>, go to you WebApp and select 'Deployment options' and then follow the instructions.
Then in AppSettings, add:
WEBSITE_NODE_DEFAULT_VERSION: 6.9.1

## 2/ Configure the WebApp csproj
Edit your WebApp csproj and add the following line:
```
  <Target Name="PostpublishScript" AfterTargets="Publish">
    <Exec Command="dotnet publish ..\..\[FACULTATIVE FOLDER]\[WEBJOB NAME]\ -o $(PublishDir)App_Data\Jobs\[Triggered || Continuous]\[WEBJOB NAME]" />
  </Target>
```
