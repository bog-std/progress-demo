﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FuncLib
{
    // Interpolation function from Unreal
    public static float FInterpTo(float current, float target, float deltaTime, float interpSpeed)
    {
        // If no interp speed, jump to target value
        if( interpSpeed <= 0.0f )
        {
            return target;
        }

        // Distance to reach
        float dist = target - current;
        
        // If distance is too small, just set the desired location
        if( dist * dist < 1e-8 )
        {
            return target;
        }
        
        // Delta Move, Clamp so we do not over shoot.
        float deltaMove = dist * Mathf.Clamp(deltaTime * interpSpeed, 0.0f, 1.0f);

        return current + deltaMove;
    }
    
    public static float FInterpConstantTo( float current, float target, float deltaTime, float interpSpeed )
    {
        float dist = target - current;
 
        // If distance is too small, just set the desired location
        if( dist * dist < 1e-8 )
        {
            return target;
        }
 
        float step = interpSpeed * deltaTime;
        return current + Mathf.Clamp(dist, -step, step);
    }

}
