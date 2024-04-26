import { PagedItemCollection } from "@pnp/sp/items";
import { IImageGallery } from "../../../interfaces/IImageGallery";
export interface IImageGalleryState {
  imgGalleryList: {
    title: string;
    image: string;
  }[];
  hasNext: boolean;
  items: PagedItemCollection<IImageGallery[]>;
  isLoading: boolean;
}
