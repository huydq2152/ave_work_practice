import { IFolderInfo } from "@pnp/sp/folders";

export interface IDocumentGalleryState {
  isLoading: boolean;
  categoryItems: IFolderInfo[];
}
