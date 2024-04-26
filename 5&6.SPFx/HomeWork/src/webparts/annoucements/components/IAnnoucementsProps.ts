import { WebPartContext } from "@microsoft/sp-webpart-base";
export interface IAnnoucementsProps {
  listTitle: string;
  context: WebPartContext;
  pageNum: number;
}
