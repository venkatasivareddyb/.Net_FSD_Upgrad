import { getEvents, registerForEvent, updateSeats } from "../services/apiService.js";
import Registration from "../models/Registration.js";

const form = document.getElementById("registrationForm");
const eventSelect = document.getElementById("eventId");
const message = document.getElementById("message");

// Populate event dropdown
(async () => {
  const events = await getEvents();
  eventSelect.innerHTML = events.map(event =>
    `<option value="${event.id}">${event.title} (${event.availableSeats} seats left)</option>`
  ).join("");
})();

// Handle registration form
form.addEventListener("submit", async (e) => {
  e.preventDefault();

  const registration = new Registration(
    null,
    parseInt(eventSelect.value, 10),
    form.participantName.value.trim(),
    form.email.value.trim(),
    form.phone.value.trim()
  );

  const error = registration.validate();
  if (error) {
    message.textContent = error;
    message.className = "text-danger";
    return;
  }

  // Check seat availability
  const events = await getEvents();
  const selectedEvent = events.find(ev => ev.id === registration.eventId);
  if (selectedEvent.availableSeats <= 0) {
    message.textContent = "No seats available for this event.";
    message.className = "text-danger";
    return;
  }

  await registerForEvent(registration);
  await updateSeats(selectedEvent.id, selectedEvent.availableSeats - 1);

  message.textContent = "Registration successful!";
  message.className = "text-success";
  form.reset();
});