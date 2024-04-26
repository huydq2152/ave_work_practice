### Single line of text
Displays small amounts of unformatted text in a single line, including:

**[andrew.pham]:**

* Text only, such as first names, last names, or department names
* Combinations of text and numbers, such as street addresses or account numbers
* Numbers that are not used in calculations, such as employee ID numbers, phone numbers, postal codes, or part numbers
Maximum length: 255 characters
**[william.le]:**

More options: 
* **Assign a character limit** : Limit the number of characters by setting the **Maximum number of characters** that you want.
* **Display a default value** : Automatically display specific text when someone adds a new item, while also allowing people to enter different text if they need to do so. When you set the **Default value**, people can enter information faster by accepting the default unless they need to change it. 
### Multiple lines of text

Displays formatted text or lengthy text and numbers on more than one line, such as a description of an item.

Maximum length: 63,999 characters

You can specify the number of lines of text that you want to display when people enter information about an item.

This type of column displays all the text when the column is viewed in a list or library.

You can customize a **Multiple lines of text** column in these ways:

* **Use enhanced rich text (Rich text with pictures, tables, and hyperlinks)** (Only available in lists)  This option allows for basic formatting such as bold, italics, bulleted or numbered lists, colored text, and background colors, as well as hyperlinks, pictures, and tables. 

* **Append Changes to Existing Text** (Only available in lists) If versioning has been enabled for the list, this option lets people add new text about an item without replacing any existing text about that item. If you choose to append changes, people can enter additional information about an item, while also viewing text that was previously entered, plus the date and time that the text was entered. When viewed in a list (not as a field in an item form) the column displays the hyperlink **View Entries**, instead of the text, and people can click the hyperlink to see all the information stored in the column for that item.
If you choose to not append changes, new text about an item replaces any existing text about that item in the column.
` **Important**: If you turn off this option after you create the column, all information except the most recent entry is deleted. `

-----

### Choice (menu to choose from)
**[william.le]:**

Lets people choose from a list of options that you provide. This column type is an ideal choice in cases where you want to ensure that all the data in the column is consistent because you can limit the values that are stored in a column.
People can choose from either a drop-down menu or option buttons. To choose between these formats, select More options, then under Display choices using, select your preferred format.
**[andrew.pham]:**

Lets people choose from a list of options that you provide. This column type is an ideal choice in cases where you want to ensure that all the data in the column is consistent because you can limit the values that are stored in a column.
People can choose from either a drop-down menu or option buttons. To choose between these formats, select More options, then under Display choices using, select your preferred format.
You can also customize a Choice column in these ways:
* **Define the list of choices**
* **Enable additional custom choices**

Lets people choose from a list of options that you provide. This column type is an ideal choice in cases where you want to ensure that all the data in the column is consistent because you can limit the values that are stored in a column.

People can choose from either a drop-down menu or option buttons. To choose between these formats, select **More options**, then under **Display choices using**, select your preferred format.

You can also customize a **Choice** column in these ways:

* **Define the list of choices**    Provide an exact list of values that people can choose. To provide this list, replace the sample text in the **Choices** box with the values that you want. Type each value on a separate line. To start a new line, press Enter.

* **Enable additional custom choices**    To allow people to enter a value that is not included in the list of choices, turn on **Can add values manually**. Doing so is a good idea if you may not know all the values that people need to enter about items. If you prefer that people use only the values that you specify, turn off **Can add values manually**.

-----

### Number

Stores numerical values that aren't monetary values.

Tips for choosing between **Number** and **Currency** columns:

Both the **Number** and **Currency** column types store numerical values, and both provide predefined formats that determine how data appears.

* Use a **Number** column to store numeric data for mathematical calculations that aren't financial calculations or don't require a high degree of accuracy.

* Use a **Currency** column to store numeric data for financial calculations or in cases where you do not want round numbers in calculations. Unlike a **Number** column, a **Currency** column is accurate 15 digits to the left of the decimal point and 4 digits to the right.

You can customize a **Number** column in these ways:

* **Specify minimum and maximum values**    Limit the range of numbers that people can enter. For example, if the column stores the number of attendees for an event and you want to limit attendees to a specific number, you can enter the maximum number of attendees as the maximum value.

* **Include decimal places**    Specify whether the numbers contain decimal places and the number of decimal places to store. If the column may need to store numbers that have more than five decimal places, you can choose **Automatic**. **Automatic** is also a good choice if the column stores the results of calculations and you want the result to be as precise as possible. However, if you want to ensure that all values in the column have the same number of decimal places, it's a good idea to limit the number of decimal places to zero, for whole numbers only, or another number of decimal places through five.

* **Format the number as a percentage**    The **Show as percentage** setting lets you display and store the number as a percentage, and to treat it as a percentage when it is used to calculate other values.

-----

### Currency
**[andrew.pham]:**

Stores monetary values.
Use a Currency column to store numeric data for financial calculations or in cases where you do not want round numbers in calculations. Unlike a Number column, a Currency column is accurate 15 digits to the left of the decimal point and 4 digits to the right.
Customize a currency column in these ways:
* **Specify minimum and maximum allowed values**
* **Include decimal places**
* **Choose a currency format**

Stores monetary values.

Tips for choosing between **Number** and **Currency** columns:

Both the **Number** and **Currency** column types store numerical values, and both provide predefined formats that determine how data appears.

* Use a **Number** column to store numeric data for mathematical calculations that aren't financial calculations or don't require a high degree of accuracy.

* Use a **Currency** column to store numeric data for financial calculations or in cases where you do not want round numbers in calculations. Unlike a **Number** column, a **Currency** column is accurate 15 digits to the left of the decimal point and 4 digits to the right.

You can customize a **Currency** column in these ways:

* **Specify minimum and maximum allowed values**    Limit the range of currency values that people can enter. For example, if the column stores reported expenses for an event and your organization limits reporting to amounts within a specific range, you can specify those limits as the minimum and maximum values.

* **Include decimal places**    Specify whether values include decimal places and the number of decimal places to store. For currency values, you can choose two decimal places or, if you prefer to store only round values, you can choose zero. For non-monetary values used in calculations that require a high degree of accuracy, you can choose to limit the number of decimal places to zero through five or, for more precise values, choose **Automatic** to automatically use the appropriate number of decimal places for the result of the calculation.

* **Choose a currency format**    Ensure that all the values in the column are based on the same currency by selecting a specific currency format for the column. The dropdown box offers over 100 country choices so you can specify currency in most local formats.

-----

### Date and Time

Stores calendar dates, or both dates and times. The date format varies based on the regional settings for the site. If the format that you want is not available, ask your administrator to add support for the appropriate region to the site.

You can customize a **Date and time column** in these ways:

* **Include only the date or both the date and time**    Specify whether you want to include only the calendar date or both the calendar date and time of day

-----

### Lookup (information already on this site)
**[mike.dang]:**
 This field can help us to find informations that already on this site. We can lookup for informations from **Document**, **Events**, **Form template**, **Site Assets**, **Site Pages**, **Library**, and **List**. 

-----
 
**[andrew.pham]:**

Use this column field type to let people choose values based on information that is already stored in the site. For example, if you want a column to store the names of customer accounts to which employees are assigned and the list of accounts must be limited to a Customer Accounts list on the site, you can create a Lookup column that displays the names in the Customer Accounts list. The list of choices in a Lookup column appear in either an expanding box, called a drop-down menu, or a list box, depending on whether you allow people to select more than one value.
You can customize a Lookup column in these ways:
* Choose the source of the lookup values    Specify which list, library, or discussion board on your site that contains the values that you want to store in the column. The source cannot be a subsite, workspace site, wiki, or blog. After you specify the list, library, or discussion board that you want, you can specify which column in that list, library, or discussion board contains the values that you want people to choose from.
* Allow multiple selections    Allow people to choose as many values as they like or limit the number of values that they can choose to only one value. If people can choose multiple values, all the values appear in the column, separated by a semi-colon (;).
* Choose columns to display    You can add one or more columns to show specific field values for this column type.

**[william.le]:**

Use this column field type to let people choose values based on information that is already stored in the site. For example, if you want a column to store the names of customer accounts to which employees are assigned and the list of accounts must be limited to a Customer Accounts list on the site, you can create a Lookup column that displays the names in the Customer Accounts list. The list of choices in a Lookup column appear in either an expanding box, called a drop-down menu, or a list box, depending on whether you allow people to select more than one value.
You can customize a Lookup column in these ways:
* Choose the source of the lookup values    Specify which list, library, or discussion board on your site that contains the values that you want to store in the column. The source cannot be a subsite, workspace site, wiki, or blog. After you specify the list, library, or discussion board that you want, you can specify which column in that list, library, or discussion board contains the values that you want people to choose from.
* Allow multiple selections    Allow people to choose as many values as they like or limit the number of values that they can choose to only one value. If people can choose multiple values, all the values appear in the column, separated by a semi-colon (;).
* Choose columns to display    You can add one or more columns to show specific field values for this column type.


### Yes/No (check box)
**[andrew.pham]:**

Stores true/false or yes/no information, such as whether someone will attend an event. A **Yes/No** column appears as a single check box when people enter information about an item. To indicate **Yes**, team members select the check box. To indicate No, team members clear the check box.
The data in a **Yes/No** column can be used in calculations for other columns. In these cases, **Yes** is converted to a numeric value of one (1) and **No** is converted to a numeric value of zero (0).


Stores true/false or yes/no information, such as whether someone will attend an event. A **Yes/No** column appears as a single check box when people enter information about an item. To indicate **Yes**, team members select the check box. To indicate **No**, team members clear the check box.

The data in a **Yes/No** column can be used in calculations for other columns. In these cases, **Yes** is converted to a numeric value of one (1) and **No** is converted to a numeric value of zero (0).

----

### Person or Group
**[mike.dang]:**
Provides a searchable list of people and groups from which people can choose when they add or edit an item. For example, on a Tasks list, a **Person or Group** column named **Assigned To** can provide a list of people that a task can be assigned to. The contents of the list depends on how directory services and SharePoint groups have been configured for the site. To customize the contents of the list, you may need to contact your administrator.

You can customize a **Person or Group** column in these ways:

* **Allow multiple selections**    Allow people to select as many options as they like or limit the number of selections to only one option.

* **Include or exclude groups of people**    Specify whether the list includes only individual people, or additionally includes e-mail distribution lists and SharePoint groups. 

**Note**: The presence status, formerly available with Name (with presence), is not available in modern browsers. Your organization may choose to make presence available by following the steps in [Display a classic SharePoint site in Internet Explorer 10 document mode](https://support.office.com/en-us/f1/topic/display-a-classic-sharepoint-site-in-internet-explorer-10-document-mode-4b4572b7-9223-45ec-8497-557a643da12a?NS=SPOSTANDARD&Version=16).

-----

### Hyperlink or Picture

Stores a hyperlink that points to a Web page, graphic, or other resource.

A **Hyperlink** column stores the Uniform Resource Locator (URL) for a Web page, graphic, or other resource. Depending on the display format that you choose, it displays either a hyperlink that can be clicked to access the resource, or a graphic instead of the URL for the graphics file.

When a user adds a hyperlink to a list item, they must enter the URL and descriptive text that appears in the column. If the URL is for a graphics file, such as http://www.example.com/image.gif, they can optionally enter descriptive, alternative text for the graphic, which appears for people who turn off graphics in their browsers or rely on screen-reading software to convert graphics on the screen to spoken words.

----

### Calculated (calculation based on other columns)
**[andrew.pham]:**

You can use formulas and functions in SharePoint lists or libraries to calculate data in a variety of ways. By adding a calculated column to a list or library, you can create a formula that includes data from other columns and performs functions to calculate dates and times, to perform mathematical equations, or to manipulate text.

![](https://support.content.office.net/en-us/media/52c45dc2-2bf7-4798-9d29-8f73b668a0d2.png)

Stores values that can be caculated based on other columns using provided fomulas. 

The proper syntax for formulas can be found [here](https://support.office.com/en-US/client/results?Shownav=true&lcid=1033&ns=SPOStandard&version=16&omkt=en-US&ver=16&HelpId=WSSEndUser_FormulaSyntaxError).

-----

### Image
**[andrew.pham]:**

Use to add a single image file from your device to an item in a list or a library.
**[william.le]:**

Once you add an Image column to a list or library, you can:
* Add an image using the list or library form. For example, in the screenshot below Device Photo is the Image column.
* View, replace, or delete an image when viewing the item or file properties in the form by selecting the Edit (pencil) icon or the Delete (garbage can) icon.

### Managed metadata
Lets site users select values from a specific term set of managed terms and apply these values to their content. You can create and configure a Managed Metadata column to map to an existing term set or term, or you can create a new term set specifically for a Managed Metadata column.

Managed Metadata columns have several unique features and characteristics that help users select and apply terms to content, such as support for “type-ahead,” as well as support for disambiguation of terms, descriptions, synonyms, and multi-lingual values.

Managed Metadata columns promote the consistent use of metadata across sites because they provide users with a list of terms that they can apply to their content.

Adds a single image file to an item in a list or a library.

Once you add an Image column to a list or library, you can:

* Add an image using the list or library form. For example, in the screenshot below **Device Photo** is the Image column.

![example](images/image1.png)

* View, replace, or delete an image when viewing the item or file properties in the form by selecting the **Edit** (pencil) icon or the **Delete** (garbage can) icon.

![example](images/image2.png)

-----

### Managed Metadata
**[mike.dang]:**
Lets site users select values from a specific term set of managed terms and apply these values to their content. You can create and configure a Managed Metadata column to map to an existing term set or term, or you can create a new term set specifically for a Managed Metadata column.

Managed Metadata columns have several unique features and characteristics that help users select and apply terms to content, such as support for “type-ahead,” as well as support for disambiguation of terms, descriptions, synonyms, and multi-lingual values.

Managed Metadata columns promote the consistent use of metadata across sites because they provide users with a list of terms that they can apply to their content.

These terms come from a term set that is managed centrally in the Term Store Management Tool by a Term Store Administrator or other individuals with permissions to manage terms. Whenever the term set that a specific Managed Metadata column is bound to is updated, the updated terms will automatically become available to users wherever that Managed Metadata column is available.

You can customize the Managed Metadata column in the following ways:

![exampe](images/meta.png)

**Selecting a term set or term**  Specify the term set that contains the desired values to associate with this column.  

When a term set is found, click it to select the first level of the hierarchy to show in the column. The levels below the term you selected will be displayed only when the user selects a value. 

**Display a default value**  A specific value is automatically selected when someone adds a new item while allowing people to select different terms if they need to do so.  

A default value helps users enter information faster. For example, if the term set associated with the column represents the various geographies your organization operates in, and there is one predominant location term that is relevant to the content in this list or library, you can select that term as the default value. As a result, that location term is selected automatically when a new item is added to the list or library, and users do not have to select a location unless it's different. 

**Choose a display format**  The selected value from the term set can be displayed either as a single value with just the term label (example: Sydney) or with the full hierarchical path of the term & its parents (example: Geolocations: Australia: Sydney) 

**Allow users to type new values** Enabling this option will allow users to add new terms to the term set. Please note that this option is available only if the term set is specified to be open to user contributions. 

**Allow multiple values**  Selecting this option enables the column to contain more than one value. Please note that enabling this feature will prevent sorting data in list views.  

For more information on what managed metadata is and how to use it, see [Introduction to managed metadata](https://docs.microsoft.com/en-us/sharepoint/managed-metadata). 

**Note**: The Managed metadata option is currently being rolled out to Targeted Release customers and may not be available for some users.
These terms come from a term set that is managed centrally in the Term Store Management Tool by a Term Store Administrator or other individuals with permissions to manage terms. Whenever the term set that a specific Managed Metadata column is bound to is updated, the updated terms will automatically become available to users wherever that Managed Metadata column is available.
Customize the Managed Metadata column in the following ways:
* Selecting a term set or term
* Display a default value
* Choose a display format
* Allow users to type new values
* Allow multiple values
