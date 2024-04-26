import { SPFI } from "@pnp/sp";

export class ImageGalleryService {
  private listTitle: string;
  private _sp: SPFI;

  constructor(listTitle: string, _sp: SPFI) {
    this.listTitle = listTitle;
    this._sp = _sp;
  }

  public async getPagedListItems(pageNum: number) {
    var res = await this._sp.web.lists
      .getByTitle(this.listTitle)
      .items.top(pageNum)
      .getPaged();
    return res;
  }
}
