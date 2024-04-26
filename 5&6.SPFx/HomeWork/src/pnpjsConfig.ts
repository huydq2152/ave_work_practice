import { WebPartContext } from "@microsoft/sp-webpart-base";
import { spfi, SPFI, SPFx } from "@pnp/sp";

import "@pnp/sp/webs";
import "@pnp/sp/lists";
import "@pnp/sp/folders";
import "@pnp/sp/files";
import "@pnp/sp/items";

var _sp: SPFI = null;

export const getSP = (context?: WebPartContext): SPFI => {
  if (_sp === null && context != null) {
    _sp = spfi().using(SPFx(context));
  }
  return _sp;
};
