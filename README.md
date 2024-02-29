# Pal world 服务器管理
用于远程开关和更新windows平台上的帕鲁服务器，包含server和client两个项目，server为命令行应用，client为WinForm窗体应用。

## server端口
server端监听127.0.0.1:8210，可通过frp等内网穿透方式远程连接。

## client
### 开启Pal Server
client连接server后，点击'open server'，server端运行open_server.bat脚本，开启帕鲁服务器。
### 关闭Pal Server
client连接server后，点击'close server'，server端运行close_server.bat脚本，关闭帕鲁服务器。
### 更新Pal Server
client连接服务器后，点击'update server'，server运行update_server.bat脚本，通过steamcmd更新帕鲁服务器。
### 查看server资源占用
连接server后，server每秒更新cpu和内存资源占用情况，client可查看资源占用变化。

