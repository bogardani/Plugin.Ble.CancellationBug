# Plugin.Ble.CancellationBug

Cancelling token given to ConnectToDeviceAsync throws exception on Plugin.BLE\Android\Device.cs:line 186


## Steps to reproduce

1. Clone https://github.com/bogardani/Plugin.Ble.CancellationBug.git
2. Put breakpoint on line CancellationBug/MainPage.xaml.cs:line 55
3. Turn on device bluetooth
4. Run the application
5. Accept permission requests
6. Click button on UI
7. Turn off bluetooth when breakpoint is hit
8. Continue execution

## Expected behavior
ConnectToDeviceAsync cancells without exception

## Actual behavior
Cancelling the token threw an exception

### Crashlog
```
[DOTNET] System.AggregateException: One or more errors occurred. (One or more errors occurred. (Object reference not set to an instance of an object.))
[DOTNET]  ---> System.AggregateException: One or more errors occurred. (Object reference not set to an instance of an object.)
[DOTNET]  ---> System.NullReferenceException: Object reference not set to an instance of an object.
[DOTNET]    at Plugin.BLE.Android.Device.DisconnectAndClose(BluetoothGatt gatt) in D:\a\dotnet-bluetooth-le\dotnet-bluetooth-le\Source\Plugin.BLE\Android\Device.cs:line 186
[DOTNET]    at Plugin.BLE.Android.Device.<>c__DisplayClass17_0.<ConnectToGattForceBleTransportAPI>b__0() in D:\a\dotnet-bluetooth-le\dotnet-bluetooth-le\Source\Plugin.BLE\Android\Device.cs:line 158
[DOTNET]    at System.Threading.CancellationToken.<>c.<Register>b__12_0(Object obj)
[DOTNET]    at System.Threading.CancellationTokenSource.Invoke(Delegate d, Object state, CancellationTokenSource source)
[DOTNET]    at System.Threading.CancellationTokenSource.CallbackNode.<>c.<ExecuteCallback>b__9_0(Object s)
[DOTNET]    at System.Threading.ExecutionContext.RunInternal(ExecutionContext executionContext, ContextCallback callback, Object state)
[DOTNET] --- End of stack trace from previous location ---
[DOTNET]    at System.Threading.ExecutionContext.RunInternal(ExecutionContext executionContext, ContextCallback callback, Object state)
[DOTNET]    at System.Threading.CancellationTokenSource.CallbackNode.ExecuteCallback()
[DOTNET]    at System.Threading.CancellationTokenSource.ExecuteCallbackHandlers(Boolean throwOnFirstException)
[DOTNET]    --- End of inner exception stack trace ---
[DOTNET]    at System.Threading.CancellationTokenSource.ExecuteCallbackHandlers(Boolean throwOnFirstException)
[DOTNET]    at System.Threading.CancellationTokenSource.NotifyCancellation(Boolean throwOnFirstException)
[DOTNET]    at System.Threading.CancellationTokenSource.LinkedNCancellationTokenSource.<>c.<.cctor>b__4_0(Object s)
[DOTNET]    at System.Threading.CancellationTokenSource.Invoke(Delegate d, Object state, CancellationTokenSource source)
[DOTNET]    at System.Threading.CancellationTokenSource.CallbackNode.ExecuteCallback()
[DOTNET]    at System.Threading.CancellationTokenSource.ExecuteCallbackHandlers(Boolean throwOnFirstException)
[DOTNET]    --- End of inner exception stack trace ---
[DOTNET]    at System.Threading.CancellationTokenSource.ExecuteCallbackHandlers(Boolean throwOnFirstException)
[DOTNET]    at System.Threading.CancellationTokenSource.NotifyCancellation(Boolean throwOnFirstException)
[DOTNET]    at System.Threading.CancellationTokenSource.Cancel(Boolean throwOnFirstException)
[DOTNET]    at System.Threading.CancellationTokenSource.Cancel()
[DOTNET]    at CancellationBug.MainPage.<>c__DisplayClass1_0.<OnCounterClicked>g__OnStateChanged|2(Object sender, BluetoothStateChangedArgs args) in C:\Users\Dani\source\repos\CancellationBug\CancellationBug\MainPage.xaml.cs:line 43
```

## Configuration

**Version of the Plugin:** 3.0.0-beta.4

**Platform:** Android 13.0 (API 33)

**Device:** Samsung Galaxy A53 5G
