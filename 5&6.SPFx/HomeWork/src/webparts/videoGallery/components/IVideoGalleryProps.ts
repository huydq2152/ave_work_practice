import { WebPartContext } from "@microsoft/sp-webpart-base";
export interface IVideoGalleryProps {
  listTitle: string;
  context: WebPartContext;
  pageNum: number;
}
