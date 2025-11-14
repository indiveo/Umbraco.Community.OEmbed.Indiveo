# Umbraco.Community.OEmbed.Indiveo

A lightweight **Umbraco CMS plugin** that adds **OEmbed support** for *Indiveo* directly into the Umbraco Rich Text Editor (RTE).

This package allows editors to easily embed Indiveo content by simply pasting a URL — no additional configuration or coding required.

---

## 🚀 Features

- **Seamless OEmbed integration** for Indiveo
- Works **out of the box** – no setup or configuration needed
- **Automatic embedding** in the Umbraco Rich Text Editor
- Compatible with the native Umbraco **OEmbed service**
- **Lightweight & dependency-free**
- Supports both **preview** and **published content** modes

---

## 🧩 Package Information

- **Package ID:** `Umbraco.Community.OEmbed.Indiveo`
- **Namespace:** `Umbraco.Community.OEmbed.Indiveo`
- **Author:** Indiveo
- **License:** MIT

---

## 💡 How It Works

Once installed, the package automatically registers Indiveo as an OEmbed provider within Umbraco.  
When a content editor pastes a valid Indiveo URL into the Rich Text Editor, Umbraco automatically transforms it into an embedded Indiveo component using the OEmbed specification.

Example:
```bash
https://indiveo.services/embed/f1557bd7-1584-495a-aecd-827189d6a471
```

➡️ Automatically becomes an embedded Indiveo video in the RTE.

---

## 🧱 Requirements

| Requirement | Version |
|--------------|---------|
| **Umbraco CMS** | 16.x    |
| **.NET SDK** | 9.0     |

---

## ⚙️ Installation

### Option 1: NuGet
Install via the .NET CLI:
```bash
dotnet add package Umbraco.Community.OEmbed.Indiveo
```

Or via the Package Manager Console:

```bash
Install-Package Umbraco.Community.OEmbed.Indiveo
```

### Option 2: Umbraco Marketplace
Search for “OEmbed for Indiveo” and install it directly via the Umbraco backoffice package installer.

## 🧰 Configuration
No configuration is required.
The plugin automatically registers itself as an OEmbed provider and is active immediately after installation.

## 🧪 Running Tests
To run the included unit tests:

```bash
dotnet test
```

This will build the project, run all tests, and output results in the console.

## 🏗️ Building Locally
To build the project locally:

```bash
dotnet build
```

The build output will appear in the bin/ directory.

## 🧾 Notes
The plugin only activates for valid Indiveo URLs.

If you uninstall the package, Umbraco’s default OEmbed behavior will remain unaffected.

No database changes are made.

## ❤️ Contributing
Contributions are welcome!
Please open an issue or submit a pull request on the GitHub repository if you’d like to help improve the package.

## 📄 License
This project is licensed under the MIT License.