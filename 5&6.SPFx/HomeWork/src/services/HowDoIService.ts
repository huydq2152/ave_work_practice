import { SPFI } from "@pnp/sp";
import "@pnp/sp/items/get-all";

export class HowDoIService {
  private listTitle: string;
  private _sp: SPFI;

  constructor(listTitle: string, _sp: SPFI) {
    this.listTitle = listTitle;
    this._sp = _sp;
  }

  public async getAllItems() {
    var res = await this._sp.web.lists
      .getByTitle(this.listTitle)
      .items.getAll();
    return res;
  }
}
