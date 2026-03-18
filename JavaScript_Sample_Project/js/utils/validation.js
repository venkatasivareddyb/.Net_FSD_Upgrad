export function showMessage(element, text, type = "success") {
  element.textContent = text;
  element.className = type === "success" ? "text-success" : "text-danger";
}