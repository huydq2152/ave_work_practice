import { WebPartContext } from "@microsoft/sp-webpart-base";
export interface IImageGalleryProps {
  listTitle: string;
  context: WebPartContext;
  pageNum: number;
}
