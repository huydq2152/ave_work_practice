import { SPFI } from "@pnp/sp";

export class DocumentGalleryService {
  private listTitle: string;
  private _sp: SPFI;

  constructor(listTitle: string, _sp: SPFI) {
    this.listTitle = listTitle;
    this._sp = _sp;
  }

  //get folder in document category
  public async getFolders() {
    return this._sp.web.lists.getByTitle(this.listTitle).rootFolder.folders();
  }
  //get all item in a folder in document category
  public async getDocCategoryItems(
    folderServerRelativeUrl: string,
    pageSize: number,
    pageToken?: string
  ) {
    return await this._sp.web.lists
      .getByTitle(this.listTitle)
      .renderListDataAsStream({
        ViewXml: `
          <View>
            <RowLimit Paged="TRUE">${pageSize}</RowLimit>
          </View>
        `,
        Paging: pageToken,
        FolderServerRelativeUrl: `${folderServerRelativeUrl}`,
      });
  }
}
