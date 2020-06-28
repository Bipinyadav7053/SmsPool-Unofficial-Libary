## DOCS
```csharp

SMSClient client = new SMSClient("API_KEY");
 
 //order
 await client.Order("POOL", "SERVICE", "COUNTRYCODE");
 
 //order example
 var order_id = await client.Order("3", "Snapchat", "RU");
 
  //check
 await client.Check("ORDER_ID");
 
 //check example
 var order_id = await client.Order("3", "Snapchat", "RU");
 var smscode = await client.Check(order_id); // Will return Waiting if still waiting it auto refund if expired
 
 //cancel
 await client.Check("ORDER_ID");
 
  //cancel example
 var order_id = await client.Order("3", "Snapchat", "RU");
 await client.Cancel(order_id); // Cancels sms # must be over 2 mins


```
