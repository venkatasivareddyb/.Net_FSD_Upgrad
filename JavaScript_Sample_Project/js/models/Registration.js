export default class Registration {
  constructor(id, eventId, participantName, email, phone) {
    this.id = id;
    this.eventId = eventId;
    this.participantName = participantName;
    this.email = email;
    this.phone = phone;
  }

  validate() {
    if (!this.participantName) return "Name is required.";
    if (!/\S+@\S+\.\S+/.test(this.email)) return "Invalid email format.";
    if (!/^\d{10}$/.test(this.phone)) return "Phone must be 10 digits.";
    return null;
  }
}