using System.Collections.Generic;

public enum StoryPersonPosition
{
   LEFT
}

// ****************************************************************************************

public enum StoryPersonEmotion
{
   NONE,
   NORMAL,
   WOW
}

// ****************************************************************************************
public class StoryDialogButton
{
   public int nextDialogId;
   public string caption;

   public StoryDialogButton(int nextDialogId, string caption)
   {
      this.nextDialogId = nextDialogId;
      this.caption = caption;
   }
}

// ****************************************************************************************
public class StoryPerson
{
   public int personId;
   public StoryPersonPosition position;
   public StoryPersonEmotion emotion;

   public StoryPerson(int personId, StoryPersonPosition position, StoryPersonEmotion emotion)
   {
      this.personId = personId;
      this.position = position;
      this.emotion = emotion;
   }
}

// ****************************************************************************************
public class StoryDialog
{
   public int backgroundId; // scene background id
   public string text; // dialog text
   public List<StoryDialogButton> buttons; // dialog possible actions
   public StoryPerson person; // person that currently displays on screen (teller)

   public StoryDialog()
   {
      buttons = new List<StoryDialogButton>();
   }
}