# MediaMTX Proxy API (Minimal API + Swagger)

This is a small learning project built with .NET 9 that demonstrates how to work with [MediaMTX](https://github.com/bluenviron/mediamtx?tab=readme-ov-file).  
The application acts as a **proxy** to the MediaMTX API – it exposes its own endpoints (e.g. `/v3/rtmpconns/list`) while internally fetching data from the MediaMTX REST API.  
This is a hands-on way to see how a media server can be integrated with a .NET backend.

---

## Features

- Minimal API with .NET (no classic MVC controllers)  
- Proxy endpoints to MediaMTX API (e.g. `/v3/rtmpconns/list`)  
- Logic split into modules (controller-style file `MediaMtxController`)  
- Swagger UI available under `/swagger`  

---

## Requirements

- [.NET 9 SDK](https://dotnet.microsoft.com/download)  
- [MediaMTX](https://github.com/bluenviron/mediamtx?tab=readme-ov-file) with the API enabled (`api: yes` in `mediamtx.yml`)  

---

## Getting Started

1. Clone or copy this project.  
2. Restore dependencies:
   ```bash
   dotnet restore
