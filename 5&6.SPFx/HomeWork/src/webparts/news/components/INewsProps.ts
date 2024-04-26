import { WebPartContext } from "@microsoft/sp-webpart-base";
export interface INewsProps {
  listTitle: string;
  context: WebPartContext;
  pageNum: number;
}
