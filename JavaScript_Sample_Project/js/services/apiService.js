const BASE_URL = "http://localhost:3000";

export async function getEvents() {
  try {
    const res = await fetch(`${BASE_URL}/events`);
    return await res.json();
  } catch (err) {
    console.error("Error fetching events:", err);
    return [];
  }
}

export async function addEvent(eventData) {
  try {
    const res = await fetch(`${BASE_URL}/events`, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(eventData)
    });
    return await res.json();
  } catch (err) {
    console.error("Error adding event:", err);
  }
}

export async function registerForEvent(registrationData) {
  try {
    const res = await fetch(`${BASE_URL}/registrations`, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(registrationData)
    });
    return await res.json();
  } catch (err) {
    console.error("Error registering:", err);
  }
}

export async function updateSeats(eventId, availableSeats) {
  try {
    await fetch(`${BASE_URL}/events/${eventId}`, {
      method: "PATCH",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ availableSeats })
    });
  } catch (err) {
    console.error("Error updating seats:", err);
  }
}