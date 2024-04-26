import axios from "axios";
import moment from "moment";

const BASE_URL = "http://localhost:5000/";

export const ENDPOINTS = {
  NAVIGATION: "navigation",
  ANNOUNCEMENT: "announcement",
  DOCUMENT: "document",
  DOCUMENTCATEGORY: "documentCategory",
  EVENT: "event",
  HOW: "how",
  IMAGEGALLERY: "imageGallery",
  VIDEOGALLERY: "videoGallery",
  NEW: "new",
  QUICKLINK: "quickLink",
};

export const createdAPIEndPoint = (endpoint) => {
  let url = BASE_URL + endpoint + "/";
  return {
    fetchAll: () => axios.get(url),

    fetchById: (id) => axios.get(url + id),

    fetchPagedData: (pageNumber, pageSize) =>
      axios.get(url, {
        params: {
          pageNumber: pageNumber,
          pageSize: pageSize,
        },
      }),

    fetchPagedAndFilteredData: (pageNumber, pageSize, filter) =>
      axios.get(url, {
        params: {
          filter: filter,
          pageNumber: pageNumber,
          pageSize: pageSize,
        },
      }),

    fetchPagedDocumentByDocumentCategory: (
      pageNumber,
      pageSize,
      documentCategoryId
    ) =>
      axios.get(url, {
        params: {
          documentCategoryId: documentCategoryId,
          pageNumber: pageNumber,
          pageSize: pageSize,
        },
      }),
  };
};

const getMonthName = (monthNumber) => {
  const date = new Date();
  date.setMonth(monthNumber - 1);

  return date.toLocaleString("en-US", { month: "short" });
};

export const FormatDate = (date) => {
  var date = new Date(date);
  var res =
    ("0" + date.getDate()).slice(-2) +
    "/" +
    getMonthName(date.getMonth()) +
    "/" +
    date.getFullYear();
  return res;
};
