﻿CREATE TABLE [dbo].[Feedback] (
    [FeedbackID]  INT            IDENTITY (1, 1) NOT NULL,
    [EmojiID]     INT            NULL,
    [Feedback]    NVARCHAR (550) NULL,
    [CusName]     NVARCHAR (50)  NULL,
    [CusPhone]    NVARCHAR (12)  NULL,
    [CusEmail]    NVARCHAR (50)  NULL,
    [CreatedDate] DATETIME       NULL,
    CONSTRAINT [PK_Feedback] PRIMARY KEY CLUSTERED ([FeedbackID] ASC)
);

