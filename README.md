# dhookCLI
This tool allows you to send messages to a webhook endpoint easily through CLI.

## Switches
| Switch | Description | Note |
|---|---|---|
| Url | The webhook address/endpoint. | Example: https://discordapp.com/api/webhooks/x/y |
| Header | The header/title for the message. | Example: `-Header "My Title"` |
| Body | The body/content of the message. | Example: `-Body "Hello, World!"` |
| Json | A raw json object for custom messages. | Example: `-Json "{ "content": "Hello World!" }"` Ensure your quotes are escaped according to your platform. |