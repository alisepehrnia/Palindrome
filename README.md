# 🔁 Palindrome – Palindrome Generator (C#)

A small **C# console application** that reads a string from the user and **generates every possible palindrome** that can be built from the input's unique characters.

Unlike a typical “is this a palindrome?” checker, this program **constructs** palindromes: it permutes the unique characters and mirrors each permutation into a valid palindrome.

---

## 📖 Overview

The program:

1. Reads an input string from the console.
2. Normalises it — removes spaces, converts to lowercase, and **removes duplicate characters**.
3. Generates **every permutation** of the remaining unique characters.
4. For each permutation, builds a palindrome by mirroring it around its last character.
5. Prints all resulting palindromes.

Each output has length **2n − 1** (where *n* is the number of unique characters) and is guaranteed to be a palindrome.

---

## ✨ Features

- **Generates** all palindromes from a character set (not just checks one).
- **Normalisation** — ignores spaces, case, and repeated characters.
- **Recursive permutation generator** — enumerates all orderings of the unique characters.
- **Constant-time palindrome construction** per permutation (string concatenation + reversal).
- **Console interface** with author banner and prompts.

---

## 🛠️ Technologies

| Item | Details |
|------|---------|
| Language | C# |
| Runtime | .NET (uses `ToHashSet()`, so **.NET Core 2.0+ / .NET 5+**; also works with modern .NET Framework) |
| Project type | Console application |
| Dependencies | None (BCL only: `System`, `System.Collections.Generic`, `System.Linq`) |

---

## 🚀 Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (or Visual Studio with the .NET desktop/console workload).

### Run

From the project folder (the one containing the `.csproj`):

```bash
dotnet run
