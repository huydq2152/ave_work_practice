### Highlighted content
**[andrew.pham]:**

When you [add a modern page to a site](https://support.microsoft.com/en-us/office/create-and-use-modern-pages-on-a-sharepoint-site-b3d46deb-27a6-4b1e-87b8-df851e503dec#bkmk_addpage), you add and customize [web parts](https://support.microsoft.com/en-us/office/using-web-parts-on-sharepoint-pages-336e8e92-3e2d-4298-ae01-d404bbe751e0), which are the building blocks of your page.

**[william.le]:**

This article describes the Highlighted content web part.

## Add the Highlighted content web part to a page
**[andrew.pham]:**

1. If you're not in edit mode already, click **Edit** at the top right of the page.

2. Hover your mouse above or below an existing web part or under the title region, click ![](https://support.content.office.net/en-us/media/4f2608b2-0903-4452-823d-324285b89721.png), and then select the **Highlighted content** web part.

  Once the web part is on the page, you can change the title by typing over the default title **Most recent documents**.

3. Click the **Edit** button ![](https://support.content.office.net/en-us/media/acb41a52-31e0-466f-94df-e0d23039165f.png) and select your options.
**[william.le]:**

1. If you're not in edit mode already, click **Edit** at the top right of the page.

2. Hover your mouse above or below an existing web part or under the title region, click ![](https://support.content.office.net/en-us/media/4f2608b2-0903-4452-823d-324285b89721.png), and then select the **Highlighted content** web part.

  Once the web part is on the page, you can change the title by typing over the default title **Most recent documents**.

3. Click the **Edit** button ![](https://support.content.office.net/en-us/media/acb41a52-31e0-466f-94df-e0d23039165f.png) and select your options.
## Choose the content

#### Add the Highlighted content web part to a page

1. If you're not in edit mode already, click **Edit** at the top right of the page.

2. Hover your mouse above or below an existing web part or under the title region, click ![button](images/highlight1.png), and then select the **Highlighted content** web part.
Once the web part is on the page, you can change the title by typing over the default title **Most recent documents**.

3. Click the Edit button ![button](images/highlight2.png)and select your options.

#### Choose the content

Once you have added the web part and you see the web part property pane, do the following:

![image](images/highlight3.png)

1. In the **Source** dropdown, select where you want to show content from: **This site**, **A document library on this site**, **This site collection**, **The page library on this site**, **Select sites**, or **All sites**. (**This site** is selected by default.) If your site is connected to a hub site, you will also have an option to select **All sites in the hub**. 
When you select **Select sites**, you can search for the site you want to add, or select one or more sites from **Frequent sites**, or **Recent sites**. You can select up to 30 sites.

![image](images/highlight4.png)

```
Note: 

- The Select sites option is not available in SharePoint Server, U.S. Government GCC High and DoD, and Office 365 operated by 21Vianet.

- For SharePoint Server 2019, your choices are This site, A document library on this site, This site collection, and All sites.

- If you plan on using multiple filters, see how they work together in the Using multiple filters section below.
```
2. In the **Type** dropdown, select the type of content you want to show. The type of content available will depend on your source. 
If you want to show additional content types, click + **Add content type**.

---
#### Highlighted content filter
**[andrew.pham]:**

In the **Filter** dropdown, select what you want to filter by, and then enter the specific details for the filter. The filters available will depend on the content type.

* **Title includes the words** Enter the search words for the titles you want to find

* **Content includes the words** Enter the search words for the content you want to find

**[william.le]:**

* **Recently added** Enter the time period since an item was added (such as Today, Yesterday, Earlier this week, and so on).

* **Recently changed** Enter the time period since an item was changed (such as Today, Yesterday, Earlier this week, and so on).

* **Created by** Enter a user name if you choose **Selected user**. Otherwise, use **Current user**, which will filter for items created by whoever is viewing the page at the time.

* **Modified by** Enter a user name if you choose **Selected user**. Otherwise, use **Current user**, which will filter for items created by whoever is viewing the page at the time.

* **Managed property** This option is available for all Source options except Document library. Managed properties can be built-in or custom, but must be searchable. Enter a word to narrow down the list of searchable properties, select a property from the dropdown, and enter your criteria.

Once you have selected your content source and type, you can set filter and sort options to narrow down and organize the content.

1. In the **Filter** dropdown, select what you want to filter by, and then enter the specific details for the filter. The filters available will depend on the content type.
* **Title includes the words** Enter the search words for the titles you want to find
* **Content includes the words** Enter the search words for the content you want to find
* **Recently added** Enter the time period since an item was added (such as Today, Yesterday, Earlier this week, and so on).
* **Recently changed** Enter the time period since an item was changed (such as Today, Yesterday, Earlier this week, and so on).
* **Created by** Enter a user name if you choose **Selected user**. Otherwise, use **Current user**, which will filter for items created by whoever is viewing the page at the time.
* **Modified by** Enter a user name if you choose **Selected user**. Otherwise, use **Current user**, which will filter for items created by whoever is viewing the page at the time.
* **Managed property** This option is available for all Source options except Document library. Managed properties can be built-in or custom, but must be searchable. Enter a word to narrow down the list of searchable properties, select a property from the dropdown, and enter your criteria.

For general information on managed properties, see [Manage the search schema in SharePoint](https://docs.microsoft.com/vi-vn/sharepoint/manage-search-schema). For a list of available properties, see [Overview of crawled and managed properties](https://docs.microsoft.com/vi-vn/SharePoint/technical-reference/crawled-and-managed-properties-overview?redirectedfrom=MSDN).

![image](images/highlight5.png)

2. In the **Sort** by dropdown, choose your option. The default is **Most recent**.
* **Most recent**
* **Most viewed**: Shows the most viewed items across your source selection (for example, you may have selected multiple sites as your source).
* **Trending**: Shows items trending around a user. The items shown are based on activity of the user's closest network of people and include files stored in OneDrive for Business and SharePoint. Trending insights help the user to discover potentially useful content that the user has access to, but has never viewed before. For more information, see [Office Graph Insights](https://docs.microsoft.com/en-us/graph/api/resources/officegraphinsights?view=graph-rest-1.0).
* **Managed property ascending**
* **Managed property descending**

![image](images/highlight6.png)

##### Using multiple filters

Using multiple filters is a great way to narrow down your content results. When you use multiple filters, your results will be based on OR operations for filters of the same type, and AND operations for filters of different types.

* **Example**    If you select two filters: **Title includes the word Status**, and **Title includes the word Project**, your result will be all files that have Titles containing the word Status or Project.

On the other hand, if you select filters of different types, your results will be based on AND operations.

* **Example**    If you select two filters: **Title includes the word Status**, and **Created by megan**, then you will get only those files that have Status in the Title and that are also created by megan.

When you select multiple filters of different types, your results will be based on grouped OR operations for all filters of the same type, and AND operations for filters of different types, as shown here:

![image](images/highlight7.jpg)

----
#### Highlighted content Custom query

If you are familiar with using query languages, you can use Keyword Query Language (KQL) or Collaborative Application Markup Language (CAML) query strings to further customize your search.

![image](images/highlight8.png)

1. Select **Custom query**.

2. Select the source of the items you want to display. The source will determine the query language to use and the UI options you see:
* **This site**, **This site collection**, and **Select sites** use KQL query strings. For more information on KQL, see the [keyword-query-language-kql-syntax-reference](https://docs.microsoft.com/en-us/sharepoint/dev/general-development/keyword-query-language-kql-syntax-reference)
* **Document library** and **Pages library** on this site uses CAML query strings. For more information on CAML, see the [query schema for CAML](https://docs.microsoft.com/en-us/sharepoint/dev/schema/query-schema).
* When you're done entering your query string, click **Apply**.

-----
#### Highlighted content layout 

Choose **Cards**, **List**, **Filmstrip**, or **Carousel**, then enter the number of items you'd like to show and whether to show the web part when no items are found.

![image](images/highlight9.png)

---------
### News
## Add the News web part to a page
**[andrew.pham]:**

1. If your page is not already in edit mode, click **Edit** at the top right of the page.

2. Hover your mouse above or below an existing web part and you'll see a line with a circled +, like this:

![](https://support.content.office.net/en-us/media/422e81b9-517a-4665-9940-665031ca2ee0.png)

3. Click ![](https://support.content.office.net/en-us/media/4f2608b2-0903-4452-823d-324285b89721.png)

When you add a page to a site, you add and customize web parts, which are the building blocks of your page. This article describes the News web part.

You can keep everyone in the loop and engage your audience with important or interesting stories by using the News web part on your page or site. You can quickly create eye-catching posts like announcements, people news, status updates, and more that can include graphics and rich formatting.

Learn more about how news is used and distributed in the Infographic: Work with SharePoint News on [Ways to work with SharePoint](https://support.microsoft.com/en-us/office/how-to-customize-your-sharepoint-website-11de936c-8fed-4474-ac58-583d0c38ac12).

#### Add the News web part to a page

1. If your page is not already in edit mode, click **Edit** at the top right of the page.

2. Hover your mouse above or below an existing web part and you'll see a line with a circled +, like this:

![image](images/new1.png)

3. Click ![image](images/highlight1.png)

4. In the web part search box, enter News to quickly find and select the **News** web part.

![image](images/new2.png)

5. Click the **Edit** ![image](images/highlight2.png) button on the left of the web part to open the property pane and set options such as news source, layout, organization, and filtering. See below for more information on each of these options.

-----

#### News Source
**[mike.dang]:**
When you are working with a News web part, you can specify the source for your news posts. Your news posts can come from the site you are on while using the web part (**This site**), a [hub site](https://support.microsoft.com/en-us/office/what-is-a-sharepoint-hub-site-fe26ae84-14b7-45b6-a6d1-948b3966427f) that the current site is part of (**All sites in the hub**), or one or more individual sites (**Select sites**). Another option is to choose **Recommended for current user**, which will display posts for the current user from people the user works with; managers in the chain of people the user works with, mapped against the user's own chain of management and connections; the user's top 20 followed sites; and the user's frequently visited sites.


1. If you're not in edit mode already, click **Edit** at the top right of the page.

2. Select the News web part, then click **Edit** web part ![image](images/highlight2.png) on the left side of the News web part.

3. Choose **This site**, **Select sites**, or **Recommended for current user**. If your site is connected to a hub site, you will see an additional option for **All sites in the hub**.

![image](images/new3.png)

When you click **Select sites**, you can search for the site you want to add, or select one or more sites from **Sites associated with this hub**, **Frequent sites**, or **Recent sites**.

`Note: The News Source selection is not available for GCC High or DoD tenants.`

----
#### News layout

You can choose from different layouts for News. The default layout will depend on whether your site is a team site, a communication site, or part of a hub site.

On a [team site](https://support.microsoft.com/en-us/office/use-the-sharepoint-team-collaboration-site-template-75545757-36c3-46a7-beed-0aaa74f0401e), the default layout for News is called **Top story**. It includes a large image space and three additional stories.

![image](images/new4.png)

The **List** layout shows news posts in a single column.

![image](images/new5.png)

On a [communication site](https://support.microsoft.com/en-us/office/use-the-sharepoint-topic-showcase-and-blank-communication-site-templates-94a33429-e580-45c3-a090-5512a8070732) the default layout is called **Side-by-side**, and is a two-column list of stories.

![image](images/new6.png)

On a [hub site](https://support.microsoft.com/en-us/office/what-is-a-sharepoint-hub-site-fe26ae84-14b7-45b6-a6d1-948b3966427f), the default layout for News is called **Hub news**, which includes columns of stories with thumbnails and information, plus a side bar of headlines of additional stories.

![image](images/new7.png)

An additional layout is **Carousel**, which shows a large visual, and allows users to move through stories using back and next buttons, or pagination icons. You can also choose to automatically cycle through news posts in the carousel.

![image](images/new8.png)

There's also the **Tiles** layout, which shows up to five news items with thumbnails and headlines.

![image](images/new9.png)

**To change the layout**:

1. If you're not in edit mode already, click Edit at the top right of the page.

2. Click **Edit web part** ![image](images/highlight2.png) on the left side of the News web part.

3. If you want to hide the title and **See all** command at the top of the web part, change the toggle to **Off** under **Show title and commands**.

4. Select the layout you want.

![image](images/new10.png)

5. For List, Carousel, and Tiles layouts, you can use the slider to select **Number of news items to show**. For the Carousel layout, you can choose to automatically cycle through news in the carousel.

6. You can show or hide a compact view (a view without images that takes up less space) for the List layout, or show or hide a compact view on other layouts when in narrow widths (like a narrow window or in a mobile view) by sliding the toggle for **Show compact view** or **Show compact view in narrow widths** to **On** or **Off**.
