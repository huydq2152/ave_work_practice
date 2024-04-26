import { WebPartContext } from "@microsoft/sp-webpart-base";
export interface IDocumentGalleryProps {
  listTitle: string;
  context: WebPartContext;
  pageNumPerCategory: number;
}
