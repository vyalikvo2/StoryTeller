using System.Collections.Generic;


public class Backgounds
{
    public const int BG_1 = 1;
    public const int BG_2 = 2;
}

// ****************************************************************************************
public class Dialogs
{
    public const int DIALOG_1 = 1;
    public const int DIALOG_2 = 2;
    public const int DIALOG_3 = 3;
}

// ****************************************************************************************
public class Persons
{
    public const int PERSON_1 = 1;
}


// ****************************************************************************************
public class StoryTree
{
    private Dictionary<int, StoryDialog> _dialogs;
    
    // ------------------------------------------------------------------------------------------
    public StoryTree(Dictionary<int, StoryDialog> dialogs)
    {
        _dialogs = dialogs;
    }
    
    // ------------------------------------------------------------------------------------------
    public StoryDialog GetDialog(int id)
    {
        return _dialogs.ContainsKey(id) ? _dialogs[id] : null;
    }
    
    // ------------------------------------------------------------------------------------------
    // Hardcoded data
    // TODO: parse story tree from bundle xml or json
    public static StoryTree GetDefaultStoryTree()
    {
        Dictionary<int, StoryDialog> dialogs = new Dictionary<int, StoryDialog>();
        
        // ***
        // Dialog 1
        // ***
        
        StoryDialog dialog1 = new StoryDialog();
        dialog1.backgroundId = Backgounds.BG_1;
        dialog1.text = "Начало истории, нажмите кнопку чтобы увидеть персонажа!";
        dialog1.buttons = new List<StoryDialogButton>
        {
            new StoryDialogButton(Dialogs.DIALOG_2, "Дальше")
        };

        dialogs[Dialogs.DIALOG_1] = dialog1;
        
        // ***
        // Dialog 2
        // ***
        
        StoryDialog dialog2 = new StoryDialog();
        dialog2.backgroundId = Backgounds.BG_2;
        dialog2.person = new StoryPerson(Persons.PERSON_1, StoryPersonPosition.LEFT, StoryPersonEmotion.NORMAL);
        dialog2.text = "Я персонаж новеллы, у меня нормальное настроение!";
        dialog2.buttons = new List<StoryDialogButton>
        {
            new StoryDialogButton(Dialogs.DIALOG_3, "Поднять настроение")
        };

        dialogs[Dialogs.DIALOG_2] = dialog2;
        
        // ***
        // Dialog 2
        // ***
        
        StoryDialog dialog3 = new StoryDialog();
        dialog3.backgroundId = Backgounds.BG_2;
        dialog3.person = new StoryPerson(Persons.PERSON_1, StoryPersonPosition.LEFT, StoryPersonEmotion.WOW);
        dialog3.text = "У меня поднялось настроение!";
        dialog3.buttons = new List<StoryDialogButton>
        {
            new StoryDialogButton(Dialogs.DIALOG_1, "В начало истории")
        };

        dialogs[Dialogs.DIALOG_3] = dialog3;
        
        return new StoryTree(dialogs);
    }
}
