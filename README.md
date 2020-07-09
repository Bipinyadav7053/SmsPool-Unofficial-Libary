## DOCS
```csharp

//init client
SMSClient client = new SMSClient("API_KEY");
 
 //order
 await client.Order("POOL", "SERVICE", "COUNTRYCODE");
 
 //order example
 SMSClient client = new SMSClient("API_KEY");
 var number = await client.Order("3", "Snapchat", "RU");
 var order_id = client.Order_ID;
 
//check
smswait:
await client.Check("ORDER_ID");
while (smscode == "Waiting.")
{
	await Task.Delay(1000);
	goto smswait; //wouldn't recommend using this but it works for newbs
}
 
 //check example
 SMSClient client = new SMSClient("API_KEY");
 var number = await client.Order("3", "Snapchat", "RU");
 var order_id = client.Order_ID;
 var smscode = await client.Check(order_id); // Will return Waiting if still waiting it auto refund if expired
 
 //cancel
 await client.Cancel("ORDER_ID");
 
  //cancel example
 SMSClient client = new SMSClient("API_KEY");
 var number = await client.Order("3", "Snapchat", "RU");
 var order_id = client.Order_ID;
 await client.Cancel(order_id); // Cancels sms # must be over 2 mins


```
