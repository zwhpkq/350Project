var app = require('express')();
var http = require('http').Server(app);
var io = require('socket.io')(http);
app.get('/', function(req, res){
  res.sendFile(__dirname + '/index.html');
});
io.on('connection', function(socket){
    console.log('a user connected')
    socket.on("join", function (name){
    io.emit("join", name)
    })
    socket.on("message", function (msg) {
    io.emit("message", msg) //broadcast new message
    })
});
http.listen(3000, function() {
    console.log('listening on *:3000');
});