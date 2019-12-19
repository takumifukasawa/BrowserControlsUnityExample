
const WebSocket = require('ws');
const WebSocketServer = WebSocket.Server;
const wss = new WebSocketServer({
  port: 8080
});

const admin = require("firebase-admin");

const serviceAccount = require("./serviceAccountKey.json");

admin.initializeApp({
  credential: admin.credential.cert(serviceAccount),
  databaseURL: "https://browsercontrolsunity.firebaseio.com"
});

const db = admin.database();
const ref = db.ref("coords");

ref.on('value', (snapshot) => {
  const val = snapshot.val();
  const sendValue = `${val.x},${val.y}`; 
  // for debug
  console.log("==================");
  console.log("value changed.");
  console.log(val);
  console.log(sendValue);
  wss.clients.forEach((client) => {
    if(client.readyState === WebSocket.OPEN) {
      client.send(sendValue);
    }
  });
}, (errorObject) => {
  console.log(`failed: ${errorObject.code}`);
});