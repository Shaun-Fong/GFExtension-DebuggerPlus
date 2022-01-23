# GFExtension-DebuggerPlus

[![75M8t1.png](https://s4.ax1x.com/2022/01/23/75M8t1.png)](https://imgtu.com/i/75M8t1)



[![75MGfx.png](https://s4.ax1x.com/2022/01/23/75MGfx.png)](https://imgtu.com/i/75MGfx)



## 使用

把目录`~Example/Prefabs`下的`DebuggerPlus`拖入场景中运行。

### 命令行功能使用

使用命令行功能您将会要用到C#的Attribute(特性)。

添加一个命令如下的静态代码

```C#
[RegisterCommand(Name = "test", Help = "Example Command")]
static void ExampleCommandTest(CommandArg[] args)
{
    Debug.Log("ExampleCommandTest");
}
```

## 安装

使用该增强调试器前请先确保您有安装[GameFramework](http://gameframework.cn)。



通过[Release](https://github.com/Shaun-Fong/GFExtension-DebuggerPlus/releases)下载UnityPackage，Unity直接导入即可。



## 报错

您导入可能会遇到提示报错，是因为没有正确引用程序集。只需要按照下方方法调整方可正常使用。



[![75Ml79.png](https://s4.ax1x.com/2022/01/23/75Ml79.png)](https://imgtu.com/i/75Ml79)



### Editor



[![75M3kR.png](https://s4.ax1x.com/2022/01/23/75M3kR.png)](https://imgtu.com/i/75M3kR)



在Unity的Project窗口视图中，请进入如下路径目录`DebuggerPlus/Editor/`找到`DebuggerPlus.Editor.asmdef`



选中丢失引用的程序集，点击-号移除，点击+号分别添加如下程序集引用



1. GameFramework

2. UnityGameFramework.Editor

3. UnityGameFramework.Runtime

### Runtime



[![75MQ0J.png](https://s4.ax1x.com/2022/01/23/75MQ0J.png)](https://imgtu.com/i/75MQ0J)



在Unity的Project窗口视图中，请进入如下路径目录`DebuggerPlus/Runtime/`找到`DebuggerPlus.Runtime.asmdef`



选中丢失引用的程序集，点击-号移除，点击+号分别添加如下程序集引用



1. GameFramework

2. UnityGameFramework.Runtime



## 使用到的开源仓库

[GitHub - stillwwater/command_terminal](https://github.com/stillwwater/command_terminal)

[GitHub - EllanJiang/GameFramework](https://github.com/EllanJiang/GameFramework)
