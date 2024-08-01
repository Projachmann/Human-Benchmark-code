using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VerbalController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI wordText;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject againButton;
    [SerializeField] GameObject menuButton;
    bool gameOver = false;
    bool clicked = false;
    int randomWord;
    int level = 1;
    List<string> seenWords = new List<string>();
    List<string> words = new List<string>();

    void Start()
    {
        AddToList();
        StartCoroutine(Game());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Game()
    {
        randomWord = UnityEngine.Random.Range(0, words.Count);
        wordText.text = words[randomWord];
        while (!clicked)
        {
            yield return null;
        }
        clicked = false;
        level++;
        while (!gameOver)
        {
            levelText.text = $"Level: {level}";
            int random = UnityEngine.Random.Range(1, 3);
            if (random == 1)
            {
                randomWord = UnityEngine.Random.Range(0, words.Count);
                wordText.text = words[randomWord];
                while (!clicked)
                {
                    yield return null;
                }
                clicked = false;
            }
            else
            {
                int randomSeenWord = UnityEngine.Random.Range(0, seenWords.Count);
                randomWord = words.IndexOf(seenWords[randomSeenWord]);
                wordText.text = seenWords[randomSeenWord];
                while (!clicked)
                {
                    yield return null;
                }
                clicked = false;
            }
            level++;
        }
        wordText.text = null;
        gameOverText.SetActive(true);
        menuButton.SetActive(true);
        againButton.SetActive(true);
    }
    public void SeenButton()
    {
        clicked = true;
        if (!seenWords.Contains(words[randomWord]))
        {
            gameOver = true;
        }
    }
    public void NewButton()
    {
        clicked = true;
        if (seenWords.Contains(words[randomWord]))
        {
            gameOver = true;
        }
        else
        {
            seenWords.Add(words[randomWord]);
        }
    }

    void AddToList()
    {
        words.AddRange(new string[] {"ability", "absence", "academy", "access", "accident", "account", "achievement", "act", "action", "activity", "actor", "ad", "addition", "address", "administration", "admission", "adult", "advance", "advantage", "advertisement", "advice", "affair", "affection", "age", "agency", "agent", "agreement", "aid", "aim", "air", "airline", "airport", "alarm", "album", "alcohol", "alert", "alliance", "allowance", "ambition", "amount", "analysis", "analyst", "anxiety", "apartment", "appeal", "appearance", "application", "appointment", "appreciation", "approach", "approval", "argument", "arrangement", "arrest", "arrival", "article", "artist", "aspect", "assignment", "assistance", "assistant", "association", "assumption", "atmosphere", "attack", "attempt", "attention", "attitude", "attraction", "audience", "author", "authority", "award", "awareness", "baby", "background", "balance", "ball", "ban", "bank", "bar", "base", "baseball", "basis", "basket", "bat", "bath", "bathroom", "battle", "beach", "bear", "beat", "beauty", "bed", "bedroom", "beer", "beginning", "being", "belief", "bell", "belt", "benefit", "beyond", "bicycle", "bid", "bike", "bill", "bird", "birth", "birthday", "bit", "bite", "bitter", "black", "blame", "blanket", "blessing", "block", "blood", "blow", "blue", "board", "boat", "body", "bone", "bonus", "book", "boom", "boot", "border", "boss", "bother", "bottle", "bottom", "bowl", "box", "boy", "boyfriend", "brain", "branch", "brass", "bread", "break", "breakfast", "breast", "breath", "brick", "bridge", "brief", "brilliant", "brother", "brown", "brush", "buddy", "budget", "bug", "building", "bunch", "burn", "burst", "bus", "bush", "business", "buyer", "cabinet", "cable", "cake", "calendar", "call", "calm", "camera", "camp", "campaign", "campus", "can", "cancel", "cancer", "candidate", "candle", "candy", "cap", "capital", "captain", "car", "card", "care", "career", "carpet", "carry", "case ", "cash", "casino", "cast", "cat", "catch", "category", "cause", "celebration", "cell", "champion", "championship", "chance", "change", "channel", "chapter", "charity", "chart", "check", "cheek", "cheese", "chef", "chemical", "chemistry", "chest", "chicken", "chief", "child", "childhood", "chip", "choice", "church", "cigarette", "city", "claim", "class", "classic", "classroom", "clerk", "client", "climate", "climb", "clock", "closet", "clothes", "cloud", "club", "clue", "coach", "coal", "coast", "coat", "code", "coffee", "cold", "collar", "collection", "college", "combination", "comedy", "comfort", "command", "comment", "commercial", "commission", "commitment", "committee", "communication", "community", "company", "comparison", "competition", "complaint", "complex", "complication", "computer", "concentration", "concept", "concern", "concert", "conclusion", "condition", "conference", "confidence", "conflict", "confusion", "connection", "consequence", "consideration", "consistency", "constant", "construction", "consultant", "contact", "contest", "context", "contract", "contribution", "control", "conversation", "convert", "cookie", "copy", "corner", "cost", "cottage", "couch", "count", "counter", "country", "county", "couple", "courage", "course", "court", "cousin", "cover", "cow", "crack", "craft", "crash", "cream", "credit", "crew", "cricket", "crime", "crisis", "criticism", "cross", "crowd", "crown", "cruise", "crush", "cry", "culture", "cup", "currency", "current", "curve", "customer", "cut", "cycle", "dad", "damage", "dance", "danger", "dark", "darkness", "data", "date", "daughter", "day", "dead", "deal", "dealer", "death", "debate", "debt", "decision", "deck", "decline", "decrease", "dedication", "deep", "defeat", "defense", "definition", "degree", "delay", "delight", "delivery", "demand", "democracy", "demonstration", "dentist", "department", "departure", "dependence", "deposit", "depression", "depth", "description", "design", "designer", "desire", "desk", "detail", "detective", "development", "device", "devil", "diamond", "difference", "difficulty", "dig", "dimension", "dinner", "direction", "director", "dirt", "disaster", "discipline", "discount", "discovery", "discussion", "disease", "dish", "dismissal", "display", "distance", "district", "divorce", "doctor", "document", "dog", "door", "dot", "double", "doubt", "draft", "drag", "drama", "draw", "drawer", "drawing", "dream", "dress", "drink", "drive", "driver", "drop", "drug", "drunk", "dryer", "duck", "due", "dump", "dust", "duty", "ear", "earth", "ease", "east", "eat", "economics", "economy", "edge", "editor", "education", "effect", "efficiency", "effort", "egg", "election", "elevator", "emergency", "emotion", "emphasis", "employer", "employment", "end", "energy", "engine", "engineer", "engineering", "entertainment", "enthusiasm", "entrance", "entry", "environment", "episode", "equal", "equipment", "equivalent", "error", "escape", "essay", "establishment", "estate", "estimate", "evaluation", "evening", "event", "evidence", "exam", "examination", "example", "exchange", "excitement", "excuse", "exercise", "exhibition", "existence", "exit", "expansion", "expectation", "expense", "experience", "experiment", "expert", "explanation", "expression", "extent", "external", "extreme", "eye", "face", "fact", "factor", "factory", "faculty", "fail", "failure", "fall", "familiar", "family", "fan", "fantasy", "farm", "farmer", "fashion", "fat", "father", "fault", "fear", "feature", "fee", "feed", "feedback", "feel", "feeling", "fellow", "female", "fence", "festival", "few", "field", "fight", "figure", "file", "film", "final", "finance", "finding", "finger", "finish", "fire", "fish", "fishing", "fix", "flag", "flame", "flash", "flat", "flavor", "flight", "floor", "flow", "flower", "fly", "focus", "fold", "food", "foot", "football", "force", "forest", "form", "fortune", "foundation", "founder", "frame", "freedom", "freeze", "frequency", "friend", "friendship", "front", "fruit", "fuel", "fun", "function", "fund", "funeral", "funny", "furniture", "future", "gain", "gallery", "game", "gap", "garage", "garbage", "garden", "garlic", "gas", "gate", "gather", "gear", "gene", "general", "generation", "genius", "gift", "girlfriend", "glad", "glass", "glove", "goal", "god", "gold", "golf", "good", "government", "grab", "grade", "graduate", "grain", "grandfather", "grandmother"});
    }

    public void Again()
    {
        SceneManager.LoadScene(1);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
