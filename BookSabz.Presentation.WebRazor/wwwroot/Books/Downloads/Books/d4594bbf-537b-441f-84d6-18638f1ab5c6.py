from pyrogram import filters, Client
from pyrogram.types import Message
from re import IGNORECASE
from os import remove

api_id = 00
api_hash = '00'
app = Client('MazCli', api_id, api_hash)

@app.on_message(filters.me & filters.regex('^download$', IGNORECASE))
async def download(app: app, message: Message):
    if message.reply_to_message and message.reply_to_message.media:
        await message.delete()
        await app.send_photo('self', name := await message.reply_to_message.download())
        remove(name)

if __name__ == '__main__':
    app.run()