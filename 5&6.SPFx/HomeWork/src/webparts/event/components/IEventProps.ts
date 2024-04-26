import { WebPartContext } from "@microsoft/sp-webpart-base";
export interface IEventProps {
  listTitle: string;
  context: WebPartContext;
  pageNum: number;
}
