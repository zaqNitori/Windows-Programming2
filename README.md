# Windows-Programming2
第二項作業 -> 繪圖
內容為 實作在Window From 與 Window APP 運行的繪圖程式
並且藉由實作此系統來學習Design Pattern

此項作業使用到的Pattern
* MVC          -> 將UI、資料與邏輯分層
* Observer     -> 底層修改時，需要連通知UI介面修改
* Builder      
* Adaptor      -> 由於 APP 與 Form API 不同，因此使用 Adaptor 來將Model 轉換成各自可以執行的Code
* Factory      -> 藉由工廠來動態產生IShape物件， 而不須使用 if / switch

使用額外套件 Dr.Smell 來檢測 Code Quality

