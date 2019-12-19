# BrowserControlsUnityExample

![simple_sphere_Trim_640](https://user-images.githubusercontent.com/947953/71169773-15d96500-229d-11ea-82d9-344ec472eb05.gif)
![vfx_move_Trim_640](https://user-images.githubusercontent.com/947953/71169774-1671fb80-229d-11ea-8d41-8d977d436688.gif)

## Works

- Windows10
- Unity 2019.2.15f HDRP
- Node.js: v12.13.1 (on command prompt)
- SmartPhone WebBrowser (Compatible ES6)

## Pipeline

WebBrowser -> Firebase -> WebSocket -> Unity

## Preparing

create firebase project and set firebase key.

1. WebController/index.html 's part of "xxxxx"

2. place WebSocketServer/serviceAccountKey.json

## Usage

### 1. Launch Node.js Server for WebSocket

```
> cd WebSocketServer
> npm i
> npm start // begin node server port:8080
```

### 2. Play Unity

open unity and Play `Scenes/Sample.unity` or `Sample_VFX.unity`

### 3. Open Webpage for Client

Open webpage by browser-sync.

```
> cd WebController
> npm i
> npm start // open browser sync

or

> cd WebController
> npm i -g browser-sync
> browser-sync --start --server
```