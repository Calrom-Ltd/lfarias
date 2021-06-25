using System;
using System.Collections.Generic;

namespace API_projTraining.Services
{
    public class MessageServices
    {

        public int[] msgId = { 11, 22, 33, 44, 55, 66, 77, 88, 99, 1010 };
        public int[] userId = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        public string[] subject = { "alfa", "bravo", "charlie", "delta", "eco", "foxtrot", "golf", "hotel", "india", "juliet" };
        public string[] body = { "alfa", "bravo", "charlie", "delta", "eco", "foxtrot", "golf", "hotel", "india", "juliet" };
        public Messages FindMessage(int messageId)
        {
            Messages mymessage = new();
            if (messageId == 1)
            {
                int i = messageId - 1;
                mymessage.MsgId = msgId[i];
                mymessage.UserId = userId[i];
                mymessage.Subject = subject[i];
                mymessage.Body = body[i];
            }
            else if (messageId > 1 & messageId < 11)
            {
                int i = messageId - 1;
                mymessage.MsgId = msgId[i];
                mymessage.UserId = userId[i];
                mymessage.Subject = subject[i];
                mymessage.Body = body[i];
            }
                return mymessage;
        }

        public List<Messages> FindAllMessages()
        {
            int count = 1;
            int idx = 0;
            var mymessages = new List<Messages>();
            do
            {
                Messages mymessage = new();
                mymessage.MsgId = msgId[idx];
                mymessage.UserId = userId[idx];
                mymessage.Subject = subject[idx];
                mymessage.Body = body[idx];
                mymessages.Add(mymessage);
                idx++;
                count++;
            }
            while (count >= 1 & count <= 10);
            return mymessages;
        }

        public List<Messages> FindSomeMessages(int nOfMessages)
        {
            var count = 1;
            Random rnd = new();
            var rndMsgs = new List<Messages>();
            do
            {
                int idx = rnd.Next(msgId.Length);
                Messages mymessage = new();
                mymessage.MsgId = msgId[idx];
                mymessage.UserId = userId[idx];
                mymessage.Subject = subject[idx];
                mymessage.Body = body[idx];
                rndMsgs.Add(mymessage);
                count++;
            } while (count <= nOfMessages);
            return rndMsgs;
        }
    }
}