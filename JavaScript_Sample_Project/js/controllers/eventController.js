import { getEvents, addEvent } from "../services/apiService.js";
import Event from "../models/Event.js";

const eventList = document.getElementById("eventList");
const form = document.getElementById("eventForm");
const message = document.getElementById("message");

// Load events on index.html
if (eventList) {
  (async () => {
    const events = await getEvents();
    eventList.innerHTML = events.map(event => `
      <div class="col-md-4">
        <div class="event-card p-3">
          <h3>${event.title}</h3>
          <p>${event.description}</p>
          <p><strong>Date:</strong> ${event.date}</p>
          <p><strong>Location:</strong> ${event.location}</p>
          <p><strong>Seats:</strong> ${event.availableSeats}/${event.capacity}</p>
          <a href="register.html?eventId=${event.id}" class="btn btn-primary">Register</a>
        </div>
      </div>
    `).join("");
  })();
}

// Handle add-event.html form
if (form) {
  form.addEventListener("submit", async (e) => {
    e.preventDefault();
    const newEvent = new Event(
      null,
      form.title.value.trim(),
      form.description.value.trim(),
      form.date.value,
      form.location.value.trim(),
      parseInt(form.capacity.value, 10),
      parseInt(form.capacity.value, 10)
    );

    const error = newEvent.validate();
    if (error) {
      message.textContent = error;
      message.className = "text-danger";
      return;
    }

    await addEvent(newEvent);
    message.textContent = "Event added successfully!";
    message.className = "text-success";
    form.reset();
  });
}