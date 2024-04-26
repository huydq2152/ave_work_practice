export class Helper {
  public convertToMonthName(monthNumber: number) {
    const date = new Date();
    date.setMonth(monthNumber);

    return date.toLocaleString("en-US", {
      month: "short",
    });
  }

  public formatDate(date: string) {
    return (
      this.getDay(date) + "/" + this.getMonth(date) + "/" + this.getYear(date)
    );
  }

  public getDay(date: string) {
    let newDate = new Date(date);
    return ("0" + newDate.getDate()).slice(-2);
  }

  public getMonth(date: string) {
    let newDate = new Date(date);
    return this.convertToMonthName(newDate.getMonth());
  }

  public getYear(date: string) {
    let newDate = new Date(date);
    return newDate.getFullYear();
  }
}
