# ArtifactsScraper

[![C#](https://img.shields.io/badge/C%23-13.0-%23239120?logo=c-sharp)](https://learn.microsoft.com/en-us/dotnet/csharp/)
[![.NET](https://img.shields.io/badge/.NET-9.0-%23512BD4?logo=.net)](https://dotnet.microsoft.com/)
[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](https://opensource.org/licenses/MIT)

A lightweight library designed to simplify the process of scraping CFX.RE Artifact information.

---

## 🚀 Getting Started

### Usage Example
```csharp
var artifactsScraper = new ArtifactsScraper();

var commonVersions = await artifactsScraper.GetCommonArtifactsVersions();

var artifactVersions = await artifactsScraper.GetArtifactsVersions();
```
---

## 📋 Requirements

- **Recommended IDE:** JetBrains Rider (or Visual Studio 2022+).
- **.NET SDK:** .NET 9.0 or higher ([Download it here](https://dotnet.microsoft.com/download)).

Ensure that your development environment is properly configured to utilize the latest advancements in .NET 9.0 and C# 13.0.

---

## 🗺️ Roadmap

Planned features for future releases include:

- [X] Supporting multiple environments, such as **Windows** and **Linux**.

We welcome community contributions to help speed up the implementation of these features.

---

## 🤝 Contributing

We encourage developers to contribute to the project and help it grow. Here’s how you can contribute:

- Submit **Pull Requests** focusing on improvements and including proper documentation.
- Report issues or suggest enhancements through the **Issues** tab.

Your contributions help make this library better for everyone.

---

## 📜 License

This project is distributed under the **MIT License**, making it free to use and modify. For more details, refer to the [LICENSE](LICENSE) file.

---

## 📬 Contact

Feel free to reach out for questions or collaboration opportunities via one of the following:

- **Discord:** [Felipellira](https://discordapp.com/users/889898811529502740)
- **Email:** [felipeluigilira@proton.me](mailto:felipeluigilira@proton.me)
- **LinkedIn:** [linkedin.com/in/felipellira](https://www.linkedin.com/in/felipellira/)

Let’s build something amazing together!

---