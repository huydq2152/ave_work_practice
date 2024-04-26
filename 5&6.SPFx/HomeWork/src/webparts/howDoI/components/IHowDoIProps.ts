import { WebPartContext } from "@microsoft/sp-webpart-base";
export interface IHowDoIProps {
  listTitle: string;
  context: WebPartContext;
  pageNum: number;
}
