# dhookCLI
This tool allows you to send messages to a webhook endpoint easily through CLI.

## Switches
| Switch | Description | Note |
|---|---|---|
| Url | The webhook address/endpoint. | Example: https://discordapp.com/api/webhooks/x/y |
| Name | The name of the sender. | Example: `-Name "Announcer"` |
| Body | The body/content of the message. | Example: `-Body "Hello, World!"` |
| Json | A raw json object for custom messages. | Ensure your quotes are escaped according to your platform.<br>Windows: ```-Json "{ \`"content\`": \`"Hello, World!\`" }"```<br>Linux: ```-Json '{ "content": "Hello, World!" }'``` |

## Note
When using the Json switch, Name & Body are ignored so you will have to supply them yourself.