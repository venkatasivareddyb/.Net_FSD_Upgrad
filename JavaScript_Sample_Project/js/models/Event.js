export default class Event {
  constructor(id, title, description, date, location, capacity, availableSeats) {
    this.id = id;
    this.title = title;
    this.description = description;
    this.date = date;
    this.location = location;
    this.capacity = capacity;
    this.availableSeats = availableSeats;
  }

  validate() {
    if (!this.title) return "Title is required.";
    if (!this.location) return "Location is required.";
    if (new Date(this.date) < new Date()) return "Date cannot be in the past.";
    if (this.capacity <= 0) return "Capacity must be positive.";
    return null;
  }
}