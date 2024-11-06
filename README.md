# Flow Control System

這是一個用於 Unity 的流控制系統，旨在簡化和管理遊戲中的流程邏輯。該系統使用 ScriptableObject 來定義流節點和流控制管理器，並提供靈活的方式來組織和執行遊戲邏輯。
This is a flow control system for Unity, designed to simplify and manage the flow logic in games. The system uses ScriptableObject to define flow nodes and flow control managers, providing a flexible way to organize and execute game logic.

## 目錄
## Table of Contents

- [特性](#特性)
- [Features](#features)

- [使用方法](#使用方法)
- [Usage](#usage)

- [文件結構](#文件結構)
- [File Structure](#file-structure)

- [貢獻](#貢獻)
- [Contributing](#contributing)

- [許可證](#許可證)
- [License](#license)

## 特性
## Features

- 使用 ScriptableObject 定義流節點和流控制。
- Uses ScriptableObject to define flow nodes and flow control.

- 支持循環和非循環的流控制。
- Supports both looping and non-looping flow control.

- 提供簡單的 API 來啟動和執行流。
- Provides a simple API to start and execute flows.

- 支持編輯器中的上下文菜單操作，方便創建和管理流節點。
- Supports context menu operations in the editor for easy creation and management of flow nodes.


## 使用方法
## Usage

1. 創建一個新的 FlowNodeSO 類型的資源，並定義其行為。
1. Create a new resource of type FlowNodeSO and define its behavior.

2. 在 FlowControlManager 中設置主流。
2. Set the main flow in the FlowControlManager.

3. 使用 `StartFlow()` 方法啟動流，並在每幀調用 `Tick()` 方法來更新流狀態。
3. Use the `StartFlow()` method to initiate the flow, and call the `Tick()` method each frame to update the flow state.



## 文件結構
## File Structure

```
Assets/
└── _Project/
    └── _Core/
        └── Scripts/
            └── FlowControl/
                ├── core/
                │   ├── FlowControlManager.cs
                │   ├── FlowNodeSO.cs
                │   ├── FlowNodeSOBase.cs
                │   └── FlowNodeGroupSO.cs
                └── samples/
                    └── FlowNodeCollectionSO.cs
```

- **FlowControlManager.cs**: 管理流的主要類。
- **FlowControlManager.cs**: The main class that manages the flow.

- **FlowNodeSO.cs**: 定義流節點的具體實現。
- **FlowNodeSO.cs**: The concrete implementation of flow nodes.

- **FlowNodeSOBase.cs**: 所有流節點的基類。
- **FlowNodeSOBase.cs**: The base class for all flow nodes.

- **FlowNodeGroupSO.cs**: 定義流節點組的基類。
- **FlowNodeGroupSO.cs**: The base class for defining groups of flow nodes.

- **FlowNodeCollectionSO.cs**: 用於管理流節點集合的基類。
- **FlowNodeCollectionSO.cs**: The base class for managing collections of flow nodes.

## 貢獻
## Contributing

歡迎任何形式的貢獻！請提交問題或拉取請求，並在提交之前確保您的代碼通過了測試。
Contributions of any kind are welcome! Please submit issues or pull requests, and ensure your code passes tests before submitting.

## 許可證
## License

此項目使用 MIT 許可證。請參閱 [LICENSE](LICENSE) 文件以獲取更多信息。
This project is licensed under the MIT License. Please refer to the [LICENSE](LICENSE) file for more information.
