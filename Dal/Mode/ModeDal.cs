﻿using Dal.Base;
using Dal.Exercise;

namespace Dal.Mode;

public class ModeDal: BaseDal<int>
{
    public string Name { get; set; }
    
    public int Time { get; set; }
    
    public List<ExerciseDal> Exercises { get; set; }
}