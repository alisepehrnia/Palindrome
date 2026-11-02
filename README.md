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
```
--
## 💻 Example

**Input:**

```text

Enter an string that contains all of your characters:
abc

Output:
abcba
acbca
bacab
bcacb
cabac
cbabc
```

Each line is `⟨permutation⟩ + reverse(permutation without its last char)`, so `"abc"` becomes `"abc" + "ba"` → `abcba`.

### Input normalization in action
Input:  "A man a plan"
After processing: "amnpl"   (spaces removed, lowercased, duplicates removed)

> Note: because duplicates are removed, `"aab"` behaves exactly like `"ab"`.

---
## 🗂️ Project Structure

Palindrome/
├── Program.cs     # All logic: permutation generator + palindrome builder + Main

The entire program lives in one file (`Program.cs`, class `Palindrome.Program`). It contains:

| Member                           | Role                                                                         |
| -------------------------------- | ---------------------------------------------------------------------------- |
| `list`                           | Static `List<string>` holding generated permutations.                        |
| `CharsCombinationGenerator(...)` | Recursive permutation generator using `Except` to avoid reusing a character. |
| `MakeStringPalindrome(string s)` | Mirrors `s` around its last character to produce a palindrome.               |
| `Main(...)`                      | Reads input, normalises it, drives generation, prints results.               |

---
## 🧠 How It Works

### 1. Normalization

```csharp
input = input.Replace(" ", "");            // drop spaces
input = input.ToLower();                   // case-insensitive
input = new string(input.ToHashSet().ToArray()); // unique chars only
```

### 2. Permutation generation
`CharsCombinationGenerator` recursively picks each remaining character, appends it to `prefix`, and recurses with that character removed (`chars.Except(...)`).  
When `count` reaches 0, the built string is added to `list`.

- Number of permutations = **n!** for *n* unique characters.
    
### 3. Palindrome construction

```csharp
string trail = s.Replace(s.Last().ToString(), "");
return s + new string(trail.Reverse().ToArray());
```

Because the input characters are **unique**, `Replace` removes only the final character.  
The result is `s` followed by the reverse of `s` without its last character — i.e. a mirror around the middle character.

**Example:** `s = "acb"` → `trail = "ac"` → reverse `"ca"` → result `"acbca"` ✅

---
## ⚠️ Notes & Caveats

- **Empty input crashes.** If the user enters nothing (or only spaces), `s.Last()` throws `InvalidOperationException`. Add an empty-string guard if you need robustness.
- **Factorial growth.** Output count is *n*! and each output is 2n − 1 characters, so input longer than ~9–10 unique characters becomes very slow and produces enormous output.
- **Duplicates are discarded.** `"letter"` is treated as `"letr"`; the program never uses a character more than once.
- **Assumes unique characters.** `MakeStringPalindrome` uses `Replace(lastChar, "")`, which is only safe because duplicates were removed earlier.
- **All outputs are palindromes, but not all palindromes are output.** Only odd-length palindromes of form `perm + middle + reverse(prefix)` are produced; even-length palindromes (e.g. `abba`) are not generated.    

---
## 🤝 Contributing

Issues and pull requests are welcome — e.g. adding an empty-input guard, supporting even-length palindromes, or deduplicating outputs when input has repeated characters.

---
## 📄 License

Feel free to use :)
