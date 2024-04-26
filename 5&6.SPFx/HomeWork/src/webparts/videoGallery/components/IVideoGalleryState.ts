import { PagedItemCollection } from "@pnp/sp/items";
import { IVideoGallery } from "../../../interfaces/IVideoGallery";
export interface IVideoGalleryState {
  videoGalleryList: {
    title: string;
    image: string;
  }[];
  hasNext: boolean;
  items: PagedItemCollection<IVideoGallery[]>;
  isLoading: boolean;
}
