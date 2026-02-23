<!DOCTYPE html>
<html>
<body>
<script>
let amount = 4500;
let discount = 0;
if (amount >= 5000) {
  discount = amount * 0.2;
} else if (amount >= 3000) {
  discount = amount * 0.1;
}
let finalAmount = amount - discount;
console.log("Discount: " + discount);
console.log("Final Amount: " + finalAmount);
</script>
</body>
</html>